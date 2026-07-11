import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FilterModel } from '../../models/filter.model';
import { FilterHelper } from '../../helpers/filter.helper';
import { LoadingService } from '../../services/loading.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
    selector: 'product-filters',
    imports: [
        FormsModule
    ],
    templateUrl: 'product-filters.component.html'
})
export class ProductFiltersComponent {
    public filter: FilterModel = new FilterModel();
    @Output() public onFilterChange: EventEmitter<FilterModel> = new EventEmitter<FilterModel>();

    constructor(private loadingService: LoadingService,
                private router: Router,
                private activatedRoute: ActivatedRoute) {
        this.activatedRoute.queryParams.pipe(takeUntilDestroyed()).subscribe(queryParams => {
            console.log('hello from constructor');
            FilterHelper.fillFilterFromParams(this.filter, queryParams);
            this.onFilterChange.emit(this.filter);
        });
    }

    public initFilters() {
        console.log('hello from init');
        this.onFilterChange.emit(this.filter);
    }

    public applyFilters(): void {
        if (this.loadingService.getIsLoadingValue()) {
            return;
        }

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
        }).then();
    }

    public resetFilters(): void {
        if (this.loadingService.getIsLoadingValue()) {
            return;
        }

        FilterHelper.resetFilter(this.filter);
        this.router.navigate(['']).then();
    }
}
