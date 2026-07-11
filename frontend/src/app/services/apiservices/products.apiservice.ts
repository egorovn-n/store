import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';
import { Observable } from 'rxjs';
import { FilterModel } from '../../models/filter.model';

@Injectable()
export class ProductsApiService {
    private fakeProducts: ProductAndNumberDto<ProductWithImgSrc>[] = [
        new ProductAndNumberDto(new ProductWithImgSrc(0, 'картошка',10, 'favicon.ico'), Math.round(Math.random())),
        new ProductAndNumberDto(new ProductWithImgSrc(1, 'огурец',20, 'favicon.ico'), Math.round(Math.random())),
        new ProductAndNumberDto(new ProductWithImgSrc(2, 'колбаса',50, 'favicon.ico'), Math.round(Math.random())),
        new ProductAndNumberDto(new ProductWithImgSrc(3, 'квас',15, 'favicon.ico'), Math.round(Math.random())),
        new ProductAndNumberDto(new ProductWithImgSrc(4, 'яйца',20, 'favicon.ico'), Math.round(Math.random())),
        new ProductAndNumberDto(new ProductWithImgSrc(5, 'майонез',10, 'favicon.ico'), Math.round(Math.random())),
        new ProductAndNumberDto(new ProductWithImgSrc(6, 'морковь',8, 'favicon.ico'), Math.round(Math.random())),
        new ProductAndNumberDto(new ProductWithImgSrc(7, 'лук',7, 'favicon.ico'), Math.round(Math.random())),
        new ProductAndNumberDto(new ProductWithImgSrc(8, 'свёкла',11, 'favicon.ico'), Math.round(Math.random())),
        new ProductAndNumberDto(new ProductWithImgSrc(9, 'чеснок',10, 'favicon.ico'), Math.round(Math.random())),
    ]

    constructor(private httpClient: HttpClient) {

    }

    public getProducts(filter: FilterModel): Observable<ProductAndNumberDto<ProductWithImgSrc>[]> {
        return new Observable(subscriber => {
            const shuffled = this.shuffleArray(this.fakeProducts);
            subscriber.next(shuffled);
            subscriber.complete();
        });
        //return this.httpClient.post(environment.apiUrl + '/api/Products/GetItems', filters) as Observable<ProductAndNumberDto<ProductWithImgSrc>[]>;
    }

    /**
     * Перетасовывает массив используя алгоритм Фишера-Йетса
     * @param array Исходный массив
     * @returns Новый перетасованный массив
     */
    private shuffleArray<T>(array: T[]): T[] {
        // TODO для отладки
        const shuffled = [...array]; // Создаем копию, чтобы не мутировать исходный массив

        for (let i = shuffled.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [shuffled[i], shuffled[j]] = [shuffled[j], shuffled[i]];
        }

        return shuffled;
    }
}
