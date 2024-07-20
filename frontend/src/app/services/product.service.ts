//Product.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = 'http://localhost:5201/api/products';

  constructor(private http: HttpClient) {}

  getProductById(id: number): Observable<Product> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Product>(url);
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }

  createProduct(Product: any): Observable<any> {
    return this.http.post(this.apiUrl, Product);
  }

  updateProduct(id: number, Product: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, Product);
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getProductsByManage(ManageId: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}/byManage/${ManageId}`);
  }

/*   archiveProduct(id: number, archived: boolean): Observable<Product> {
    const url = `${this.apiUrl}/${id}/${archived}`;
    return this.http.patch<Product>(url,archived);
  } */

  
}
