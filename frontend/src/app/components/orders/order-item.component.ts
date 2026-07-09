import { Component, Input } from '@angular/core';
import { OrderModel } from '../../models/order.model';
import { DatePipe, NgOptimizedImage } from '@angular/common';
import { OrderHelper } from '../../helpers/order.helper';
import { RouterLink } from '@angular/router';
import { DateConstants } from '../../constants/date.constants';

@Component({
    selector: 'order-item',
    imports: [
        DatePipe,
        NgOptimizedImage,
        RouterLink
    ],
    templateUrl: './order-item.component.html'
})
export class OrderItemComponent {
    @Input() order: OrderModel | null = null;
    protected readonly OrderHelper = OrderHelper;
    protected readonly DateConstants = DateConstants;
}
