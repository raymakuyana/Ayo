import { Injectable } from '@angular/core';
import {
  HttpClientJsonpModule,
  HttpClientModule,
  HttpClient,
  HttpHeaders
} from "@angular/common/http";
import { ConversionMethodsResponse } from '../models/conversion-methods-response';
import { ConversionMethod } from '../models/conversion-method';
import { Observable, throwError  } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { ConversionResponse } from '../models/conversion-response';
import { ConversionRequest } from '../models/conversion-request';

@Injectable({
  providedIn: 'root'
})
export class ConverterService {

  apiURL: string = "http://localhost:61895";

    // Http Options
    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }  

  constructor(private http: HttpClient) { 

  }

    // HttpClient API get() method => Fetch employees list
    getConversionMethods(): Observable<ConversionMethodsResponse> {
      return this.http.get<ConversionMethodsResponse>(this.apiURL + '/api/Converter/ConversionMethods')
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
    }


 // HttpClient API post() method => Create employee
 doConversion(conversionRequest): Observable<ConversionResponse> {
  return this.http.post<ConversionResponse>(this.apiURL + '/api/Converter/Convert', JSON.stringify(conversionRequest), this.httpOptions)
  .pipe(
    retry(1),
    catchError(this.handleError)
  )
}  
    
      // Error handling 
  handleError(error) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
 }
  //-------

}
