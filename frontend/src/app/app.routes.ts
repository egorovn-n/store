import { Routes } from '@angular/router';
import { CartComponent } from './components/cart/cart.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { AdminComponent } from './components/admin/admin.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { OrderComponent } from './components/orders/order-list.component';

export const routes: Routes = [
    { path: '', component: CatalogComponent },
    { path: 'cart', component: CartComponent },
    { path: 'history', component: OrderComponent },
    { path: 'admin', component: AdminComponent },
    { path: 'login', component: LoginComponent },
    { path: 'registration', component: RegistrationComponent },
    { path: '**', redirectTo: '/' }
];
