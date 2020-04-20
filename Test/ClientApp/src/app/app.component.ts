import { Component, OnInit, OnDestroy } from '@angular/core';
import { DataService } from '../services/data.service';
import { CalculatorModel } from '../models/calculatorModel';
import { CalculationResult } from '../models/calculationResult';
import { CalculatorOperation } from '../models/calculatorOperation';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    calculatorModel = new CalculatorModel();
    calculatorResult = new CalculationResult();
    operationList: CalculatorOperation[];

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.dataService.getOperations()
        .subscribe((result: any) => {
            this.operationList = result;
        });
    }

    calculate() {
        this.dataService.calculate(this.calculatorModel)
            .subscribe((result: any) => this.calculatorResult = result);
    }
}
