//
import { Routes } from '@angular/router';
import { CompotestComponent } from './compotest/compotest.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ManageListComponent } from './components/manage-list/manage-list.component';
import { ManageDetailComponent } from './components/manage-detail/manage-detail.component';
import { AppComponent } from './app.component';
import { FilterComponent } from './components/filter/filter.component';

export const routes: Routes = [

    //{ path: '**', redirectTo: '*', pathMatch: 'full' }, // Redirect to Products component by default
    { path: 'products', component: ProductListComponent },
    { path: 'products/new', component: ProductDetailComponent }, // Route for adding new Product
    { path: 'products/:id', component: ProductListComponent }, // Route for editing existing Product
    { path: 'manages', component: ManageListComponent },
    { path: 'manages/new', component: ManageDetailComponent }, // Route for adding new Manage
    { path: 'manages/:id', component: ManageDetailComponent }, // Route for editing existing Manage
    { path: 'filter', component: FilterComponent }, // Route for editing existing Manage
  
];


