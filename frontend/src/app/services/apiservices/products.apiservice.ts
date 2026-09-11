import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FilterModel } from '../../models/filter.model';
import { environment } from '@environment/environment';
import { ProductFullDto } from '../../dtos/product-full.dto';
import { BaseApiService } from './base.apiservice';

/** Апи сервис для работы с товарами. */
@Injectable()
export class ProductsApiService extends BaseApiService {
    constructor(private httpClient: HttpClient) {
        super();
    }

    /** Получить товары. */
    public getProducts(filter: FilterModel): Observable<ProductFullDto[]> {
        let httpParams = new HttpParams();
        httpParams = this.addObjectPropertiesToHttpParams(httpParams, filter);

        return this.httpClient.get(environment.apiUrl + 'api/Products/GetProducts', { params: httpParams }) as Observable<ProductFullDto[]>;
    }
}
