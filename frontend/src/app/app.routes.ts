import { Routes } from '@angular/router';
import { CartComponent } from './components/cart/cart.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { HistoryComponent } from './components/history/history.component';
import { AdminComponent } from './components/admin/admin.component';
import { OrderComponent } from './components/order/order.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';

export const routes: Routes = [
    { path: '', component: CatalogComponent },
    { path: 'cart', component: CartComponent },
    { path: 'history', component: HistoryComponent },
    { path: 'admin', component: AdminComponent },
    { path: 'order/:id', component: OrderComponent },
    { path: 'login', component: LoginComponent },
    { path: 'registration', component: RegistrationComponent },
    { path: '**', redirectTo: '/' }
];
