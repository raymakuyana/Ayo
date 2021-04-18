import { TheError } from "./error";

export class ConversionResponse
{
    outputUnitOfMeasure?: string;
    outputValue? : number;
    errors? : Array<TheError>;
}