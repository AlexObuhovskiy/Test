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



    // product: Product = new Product();
    // products: Product[];
    // tableMode: boolean = true;

    // constructor(private dataService: DataService) { }

    // ngOnInit() {
    //     this.loadProducts();
    // }

    // loadProducts() {
    //     this.dataService.getProducts()
    //         .subscribe((data: Product[]) => this.products = data);
    // }

    // save() {
    //     if (this.product.id == null) {
    //         this.dataService.createProduct(this.product)
    //             .subscribe((data: Product) => this.products.push(data));
    //     } else {
    //         this.dataService.updateProduct(this.product)
    //             .subscribe(data => this.loadProducts());
    //     }
    //     this.cancel();
    // }
    // editProduct(p: Product) {
    //     this.product = p;
    // }
    // cancel() {
    //     this.product = new Product();
    //     this.tableMode = true;
    // }
    // delete(p: Product) {
    //     this.dataService.deleteProduct(p.id)
    //         .subscribe(data => this.loadProducts());
    // }
    // add() {
    //     this.cancel();
    //     this.tableMode = false;
    // }
}
