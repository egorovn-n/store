import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { FilterModel } from '../../models/filter.model';
import { FilterHelper } from '../../helpers/filter.helper';

@Component({
    selector: 'product-filters',
    imports: [
        FormsModule
    ],
    templateUrl: 'product-filters.component.html'
})
export class ProductFiltersComponent {
    @Input() public filter: FilterModel = new FilterModel();

    constructor(private router: Router) {
    }

    public applyFilters(): void {
        if (this.filter.priceFrom && this.filter.priceFrom < 0) {
            this.filter.priceFrom = undefined;
        }
        if (this.filter.priceTo && this.filter.priceTo < 0) {
            this.filter.priceTo = undefined;
        }
        if (this.filter.priceTo && this.filter.priceFrom && this.filter.priceTo < this.filter.priceFrom) {
            this.filter.priceTo = this.filter.priceFrom;
        }

        this.router.navigate([''], {
            queryParams: this.filter
        }).then(() => location.reload());
    }

    public resetFilters(): void {
        FilterHelper.resetFilter(this.filter);

        this.router.navigate(['']).then(() => location.reload());
    }
}
