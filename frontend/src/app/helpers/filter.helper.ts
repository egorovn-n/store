import { Params } from '@angular/router';
import { FilterModel } from '../models/filter.model';

/** Класс-помощник для фильтров */
export abstract class FilterHelper {
    /** Получить фильтр из параметров адресной строки */
    public static fillFilterFromParams(filter: FilterModel, params: Params): void {
        filter.productName = params['productName'];
        filter.priceFrom = params['priceFrom'];
        filter.priceTo = params['priceTo'];
        filter.onlyInStock = params['onlyInStock'] ? params['onlyInStock'].toLowerCase() === 'true' : true;
    }

    /** Сбросить фильтр до параметров по умолчанию */
    public static resetFilter(filter: FilterModel): void {
        filter.productName = undefined;
        filter.priceFrom = undefined;
        filter.priceTo = undefined;
        filter.onlyInStock = true;
    }
}
