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
    private _fakeOrders: OrderModel[] = [];

    get fakeOrders() {
        if (this._fakeOrders.length === 0) {
            this._fakeOrders = this.getFakeOrdersList()
        }

        return this._fakeOrders;
    }

    constructor(private http: HttpClient) {

    }

    public getOrderById(id: number): Observable<OrderModel | null> {
        return new Observable<OrderModel | null>(subscriber => {
            subscriber.next(this.getFakeOrder(id));
            subscriber.complete();
        });
        // return this.http.get(environment.apiUrl + 'api/Orders/' + id);
    }

    public getAllOrders(): Observable<OrderModel[]> {
        return new Observable<OrderModel[]>(subscriber => {
            subscriber.next(this.fakeOrders);
            subscriber.complete();
        })
        // return this.http.get(environment.apiUrl + 'api/Orders/GetAllOrders');
    }

    private getFakeOrder(id: number): OrderModel | null {
        const result = this.fakeOrders.find(order => order.id === id);
        if (!result) {
            return null;
        }

        return result;
    }

    private getFakeOrdersList(): OrderModel[] {
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

        const order2 = new OrderModel();
        order2.id = 2;
        order2.products = [
            new ProductAndNumberDto(new ProductWithImgSrc(0, 'картошка', 10, 'favicon.ico'), 2),
            new ProductAndNumberDto(new ProductWithImgSrc(2, 'морковь', 12, 'favicon.ico'), 21),
            new ProductAndNumberDto(new ProductWithImgSrc(4, 'квас', 15, 'favicon.ico'), 3)
        ];
        order2.orderStatus = OrderStatusEnum.Accepted;
        order2.orderType = OrderTypeEnum.Delivery;
        order2.total = order2.products.reduce((acc, value) =>
            acc + value.product.price * value.productsNumber, 0);
        order2.orderDateTime = new Date();

        const order3 = new OrderModel();
        order3.id = 3;
        order3.products = [
            new ProductAndNumberDto(new ProductWithImgSrc(0, 'картошка', 10, 'favicon.ico'), 2),
            new ProductAndNumberDto(new ProductWithImgSrc(2, 'морковь', 12, 'favicon.ico'), 21),
            new ProductAndNumberDto(new ProductWithImgSrc(3, 'свёкла', 12, 'favicon.ico'), 4),
            new ProductAndNumberDto(new ProductWithImgSrc(4, 'квас', 15, 'favicon.ico'), 3)
        ];
        order3.orderStatus = OrderStatusEnum.Assembly;
        order3.orderType = OrderTypeEnum.Delivery;
        order3.total = order3.products.reduce((acc, value) =>
            acc + value.product.price * value.productsNumber, 0);
        order3.orderDateTime = new Date();

        const order4 = new OrderModel();
        order4.id = 4;
        order4.products = [
            new ProductAndNumberDto(new ProductWithImgSrc(0, 'картошка', 10, 'favicon.ico'), 2),
            new ProductAndNumberDto(new ProductWithImgSrc(2, 'морковь', 12, 'favicon.ico'), 21),
            new ProductAndNumberDto(new ProductWithImgSrc(4, 'квас', 15, 'favicon.ico'), 3)
        ];
        order4.orderStatus = OrderStatusEnum.OnTheWay;
        order4.orderType = OrderTypeEnum.Delivery;
        order4.total = order4.products.reduce((acc, value) =>
            acc + value.product.price * value.productsNumber, 0);
        order4.orderDateTime = new Date();

        const order5 = new OrderModel();
        order5.id = 5;
        order5.products = [
            new ProductAndNumberDto(new ProductWithImgSrc(0, 'картошка', 10, 'favicon.ico'), 2),
            new ProductAndNumberDto(new ProductWithImgSrc(2, 'морковь', 12, 'favicon.ico'), 21),
            new ProductAndNumberDto(new ProductWithImgSrc(4, 'квас', 15, 'favicon.ico'), 3)
        ];
        order5.orderStatus = OrderStatusEnum.OnTheWay;
        order5.orderType = OrderTypeEnum.Pickup;
        order5.total = order5.products.reduce((acc, value) =>
            acc + value.product.price * value.productsNumber, 0);
        order5.orderDateTime = new Date();

        const order6 = new OrderModel();
        order6.id = 6;
        order6.products = [
            new ProductAndNumberDto(new ProductWithImgSrc(0, 'картошка', 10, 'favicon.ico'), 2),
            new ProductAndNumberDto(new ProductWithImgSrc(2, 'морковь', 12, 'favicon.ico'), 21),
            new ProductAndNumberDto(new ProductWithImgSrc(4, 'квас', 15, 'favicon.ico'), 3)
        ];
        order6.orderStatus = OrderStatusEnum.Completed;
        order6.orderType = OrderTypeEnum.Pickup;
        order6.total = order6.products.reduce((acc, value) =>
            acc + value.product.price * value.productsNumber, 0);
        order6.orderDateTime = new Date();

        return [order1, order2, order3, order4, order5, order6];
    }
}
