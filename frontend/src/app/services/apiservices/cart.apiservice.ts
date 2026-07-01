import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environment/environment';

@Injectable()
export class CartApiService {
    constructor(private httpClient: HttpClient) {

    }

    public addProduct(productId: number): void {
        this.httpClient.post(environment.apiUrl + '/api/AddProduct', productId);
    }
}
