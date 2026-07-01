import { Injectable } from '@angular/core';
import { CartApiService } from './apiservices/cart.apiservice';
import { Subject } from 'rxjs';
import { ProductIdAndNumberDto } from '../dtos/product-id-and-number.dto';

@Injectable()
export class CartService {
    private _cartChangedSubject = new Subject<[ProductIdAndNumberDto]>()
    public cartChangedSignal$ = this._cartChangedSubject.asObservable();

    constructor(private cartApiService: CartApiService) {

    }

    public addProduct(productId: number) {
        this.cartApiService.addProduct(productId);
    }
}
