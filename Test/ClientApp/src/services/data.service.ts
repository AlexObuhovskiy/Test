import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CalculatorModel } from '../models/calculatorModel';

@Injectable()
export class DataService {

    private url = "/api/calculator";
    private operationsUrl: string;
    private withColor: string;

    constructor(private http: HttpClient) {
        this.operationsUrl = this.url + '/operations';
        this.withColor = this.url + '/with-color';
    }

    getOperations() {
        return this.http.get(this.operationsUrl);
    }

    calculate(calculatorModel: CalculatorModel) {
        calculatorModel.operationType = +calculatorModel.operationType;

        return this.http.post(this.withColor, calculatorModel);
    }
}
