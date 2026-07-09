import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderModel } from '../../models/order.model';
import { ProductAndNumberDto } from '../../dtos/product-and-number.dto';
import { ProductWithImgSrc } from '../../dtos/product-with-img-src.dto';
import { OrderStatusEnum } from '../../enums/order-status.enum';
import { OrderTypeEnum } from '../../enums/order-type.enum';
import { Observable } from 'rxjs';

@Injectable()
export class OrdersApiService {
    constructor(private http: HttpClient) {

    }

    public getOrderById(id: number) {
        return new Observable<OrderModel>(subscriber => {
            subscriber.next(this.getFakeOrder());
            subscriber.complete();
        });
    }

    private getFakeOrder(): OrderModel {
        const order1 = new OrderModel();
        order1.id = 1;
        order1.products = [
            new ProductAndNumberDto(new ProductWithImgSrc(0, 'картошка', 10, 'favicon.ico'), 2),
            new ProductAndNumberDto(new ProductWithImgSrc(2, 'морковь', 12, 'favicon.ico'), 21),
            new ProductAndNumberDto(new ProductWithImgSrc(4, 'квас', 15, 'favicon.ico'), 3)
        ];
        order1.orderStatus = OrderStatusEnum.Canceled;
        order1.orderType = OrderTypeEnum.Delivery;
        order1.total = order1.products.reduce((acc, value) =>
            acc + value.product.price * value.productsNumber, 0);
        order1.orderDateTime = new Date();

        return order1;
    }
}
