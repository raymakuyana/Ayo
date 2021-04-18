import { ConversionMethod } from "./conversion-method";
import { TheError } from "./error";

export class ConversionMethodsResponse
{
    conversionMethods? : Array<ConversionMethod>;
    errors? : Array<TheError>;

  
}