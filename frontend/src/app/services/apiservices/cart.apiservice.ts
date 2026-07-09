import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environment/environment';
import { Observable } from 'rxjs';
import { ProductIdAndNumberDto } from '../../dtos/product-id-and-number.dto';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';

@Injectable()
export class CartApiService {
    private fakeItems = [
        new ProductAndNumberDto(new ProductWithImgSrc(0, 'картошка',10, 'favicon.ico'), 1),
        new ProductAndNumberDto(new ProductWithImgSrc(1, 'огурец',20, 'favicon.ico'), 2),
        new ProductAndNumberDto(new ProductWithImgSrc(2, 'колбаса',50, 'favicon.ico'), 3)
    ]

    constructor(private httpClient: HttpClient) {

    }

    public addProduct(productId: number): Observable<ProductIdAndNumberDto> {
        return this.httpClient.post(environment.apiUrl + '/api/Cart/AddProduct', productId) as Observable<ProductIdAndNumberDto>;
    }

    public getCartItems(): Observable<ProductAndNumberDto<ProductWithImgSrc>[]> {
        return new Observable<ProductAndNumberDto<ProductWithImgSrc>[]>(subscriber => {
            subscriber.next(this.fakeItems);
            subscriber.complete();
        })
        //return this.httpClient.get(environment.apiUrl + '/api/Cart/GetItems') as Observable<ProductAndNumberDto<ProductWithImgSrc>[]>;
    }
}
