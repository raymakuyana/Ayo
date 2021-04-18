import { ConversionMethod } from "./conversion-method";

export class ConversionFormData{

    conversionMethod?: ConversionMethod;
    inputValue?: string;

  
}

export class ConversionRequest{

    conversionMethodCode?: string;
    inputValue?: number;
    
    constructor(_code : string, _inputValue: number)
    {
     this.conversionMethodCode = _code;
     this.inputValue = _inputValue;
    }
  
}