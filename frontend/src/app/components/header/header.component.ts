import { Component } from '@angular/core';
import {RouterLink} from '@angular/router';

@Component({
    selector: 'header-component',
    imports: [
        RouterLink
    ],
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
    constructor() {
    }
}
