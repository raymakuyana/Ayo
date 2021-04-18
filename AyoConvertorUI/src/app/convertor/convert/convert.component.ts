import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder,  Validators } from '@angular/forms';
import { ConversionMethod } from 'src/app/models/conversion-method';
import { ConversionMethodsResponse } from 'src/app/models/conversion-methods-response';
import { ConversionFormData, ConversionRequest} from 'src/app/models/conversion-request';
import { ConversionResponse } from 'src/app/models/conversion-response';
import { ConverterService } from 'src/app/services/converter.service';
import { NgxSpinnerService } from "ngx-spinner";


@Component({
  selector: 'app-convert',
  templateUrl: './convert.component.html',
  styleUrls: ['./convert.component.css']
})
export class ConvertComponent implements OnInit {
  conversionMethodsResponse : ConversionMethodsResponse ;
  conversionResponse : ConversionResponse;
  conversionMethods : Array<ConversionMethod> = [];
  submitted = false;
  coversionForm: FormGroup;

  constructor(public converterService : ConverterService,
    private formBuilder: FormBuilder,
    private spinner: NgxSpinnerService) { 


  }

 

  ngOnInit(): void {

    this.coversionForm = this.formBuilder.group({
      inputValue : ['', Validators.required],
      conversionMethod : ['', Validators.required]
    }
    );

    this.loadConversionMethods();
  
  }

 // Get Conversion Methods
 loadConversionMethods() {
  return this.converterService.getConversionMethods().subscribe((data: {}) => {
    this.conversionMethodsResponse = data;
    this.conversionMethods = this.conversionMethodsResponse.conversionMethods;
  });
}

// convenience getter for easy access to form fields
get f() { return this.coversionForm.controls; }


  onSubmit(){
    this.submitted = true;
    this.conversionResponse = null;
     // stop here if form is invalid
          if (this.coversionForm.invalid) 
          {
            
              return;
          }
         // this.spinner.show();
          let conversionFormData : ConversionFormData  = this.coversionForm.value;
      
          var  conversionRequest  = new ConversionRequest(conversionFormData.conversionMethod.conversionMethodCode,  Number(conversionFormData.inputValue));
          this.converterService.doConversion(conversionRequest).subscribe((data: {}) => {
           // this.spinner.hide();

            this.conversionResponse = data;

        
         
          });
    

 
    
  }

  onReset() {
    this.submitted = false;
    this.coversionForm.reset();
}


}
