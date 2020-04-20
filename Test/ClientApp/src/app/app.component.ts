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
    selectedOperation: CalculatorOperation;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.dataService.getOperations()
            .subscribe((result: CalculatorOperation[]) => {
                this.operationList = result;
                if (this.operationList && this.operationList.length > 0) {
                    
                    this.onSelectChange(0);
                }
            });
    }

    calculate() {
        this.dataService.calculate(this.calculatorModel)
            .subscribe((result: any) => this.calculatorResult = result);
    }

    onSelectChange(selectedOperationValue) {
        let operationValue = +selectedOperationValue;
        let operation = this.operationList.find((op) => op.type === operationValue);
        if (!this.calculatorModel.calculationArguments || this.calculatorModel.calculationArguments.length !== operation.argumentCount) {
            this.calculatorModel.calculationArguments = new Array<number>(operation.argumentCount);
        }
        
        this.selectedOperation = operation;
    }
}
