import { Component } from '@angular/core';
import { OrderModel } from '../../models/order.model';
import { DateConstants } from '../../constants/date.constants';
import { DatePipe } from '@angular/common';
import { OrdersApiService } from '../../services/apiservices/orders.apiservice';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { OrderHelper } from '../../helpers/order.helper';
import { CartItemComponent } from '../cart/cart-item.component';

@Component({
    selector: 'order',
    imports: [
        DatePipe,
        CartItemComponent
    ],
    providers: [
        OrdersApiService
    ],
    templateUrl: './order.component.html'
})
export class OrderComponent {
    public order: OrderModel | null = null;
    protected readonly DateConstants = DateConstants;
    protected readonly OrderHelper = OrderHelper;

    constructor(route: ActivatedRoute,
                ordersApiService: OrdersApiService) {
        let orderId: number = Number(route.snapshot.params['id']);
        ordersApiService.getOrderById(orderId).pipe(take(1)).subscribe(order => {
            this.order = order;
        })
    }
}
