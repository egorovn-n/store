import { Component } from '@angular/core';
import { OrderModel } from '../../models/order.model';
import { OrderItemComponent } from './order-item.component';
import { OrdersApiService } from '../../services/apiservices/orders.apiservice';
import { take } from 'rxjs';

@Component({
    selector: 'order-list',
    imports: [
        OrderItemComponent
    ],
    providers: [
        OrdersApiService
    ],
    templateUrl: './order-list.component.html'
})
export class OrderListComponent {
    public orders: OrderModel[] = [];

    constructor(ordersApiService: OrdersApiService) {
        ordersApiService.getAllOrders().pipe(take(1)).subscribe(orders => {
            this.orders = orders;
        });
    }
}
