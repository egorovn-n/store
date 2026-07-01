import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'order',
    templateUrl: './order.component.html',
})
export class OrderComponent {
    id: number;
    constructor(private activateRoute: ActivatedRoute){
        this.id = activateRoute.snapshot.params["id"];
    }
}
