import { Routes } from '@angular/router';
import { CartComponent } from './components/cart/cart.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { AdminComponent } from './components/admin/admin.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { OrderListComponent} from './components/orders/order-list.component';
import { OrderComponent } from './components/orders/order.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

export const routes: Routes = [
    { path: '', component: CatalogComponent },
    { path: 'cart', component: CartComponent },
    { path: 'history', component: OrderListComponent },
    { path: 'order/:id', component: OrderComponent },
    { path: 'admin', component: AdminComponent },
    { path: 'login', component: LoginComponent },
    { path: 'registration', component: RegistrationComponent },
    { path: 'not-found', component: NotFoundComponent },
    { path: '**', redirectTo: '/not-found' }
];
