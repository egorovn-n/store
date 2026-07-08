import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs';

@Component({
    selector: 'product-filters',
    imports: [
        FormsModule
    ],
    templateUrl: 'product-filters.component.html'
})
export class ProductFiltersComponent {
    public productName: string | undefined = undefined;
    public priceFrom: number | undefined = undefined;
    public priceTo: number | undefined = undefined;
    public onlyInStock: boolean = true;
    @Output() public onFilterChange = new EventEmitter();

    constructor(private router: Router, activatedRoute: ActivatedRoute) {
        activatedRoute.queryParams.pipe(take(1)).subscribe(params => {
            this.productName = params['productName'];
            this.priceFrom = params['priceFrom'];
            this.priceTo = params['priceTo ='];
            this.onlyInStock = params['onlyInStock'] ? params['onlyInStock'].toLowerCase() === 'true' : true;
        });
    }

    public applyFilters(): void {
        if (this.priceFrom && this.priceFrom < 0) {
            this.priceFrom = undefined;
        }
        if (this.priceTo && this.priceTo < 0) {
            this.priceTo = undefined;
        }
        if (this.priceTo && this.priceFrom && this.priceTo < this.priceFrom) {
            this.priceTo = this.priceFrom;
        }

        this.router.navigate([''], {
            queryParams: {
                productName: this.productName,
                priceFrom: this.priceFrom,
                priceTo: this.priceTo,
                onlyInStock: this.onlyInStock
            }
        }).then();
    }

    public resetFilters(): void {
        this.productName = undefined;
        this.priceFrom = undefined;
        this.priceTo = undefined;
        this.onlyInStock = true;
        this.router.navigate(['']).then();
    }
}
