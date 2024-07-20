import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../../models/product.model';
import { ProductService } from '../../services/product.service';
import { CommonModule } from '@angular/common';
import { Manage } from '../../models/manage.model';
import { ManageService } from '../../services/manage.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class ProductListComponent implements OnInit {
  Products: Product[] = [];
  manages: Manage[] = [];

  constructor(private router: Router, private productService: ProductService) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getProducts().subscribe((products: Product[]) => {
      this.Products = products;
      console.log(products); // Check the console output
    });
  }

  deleteProduct(id: number): void {
    this.productService.deleteProduct(id).subscribe(() => {
      this.Products = this.Products.filter(product => product.id !== id);
    });
  }

  archiveProduct(id: number): void {
    const productToUpdate = this.Products.find(product => product.id === id);
    if (productToUpdate) {
      productToUpdate.archived = !productToUpdate.archived;
      this.productService.updateProduct(id, productToUpdate).subscribe(() => {
        this.router.navigate(['/products']);
      });
    }
  }

  unarchiveProduct(id: number): void {
    const productToUpdate = this.Products.find(product => product.id === id);
    if (productToUpdate) {
      productToUpdate.archived = !productToUpdate.archived;
      this.productService.updateProduct(id, productToUpdate).subscribe(() => {
        this.router.navigate(['/products']);
      });
    }
  }



  goToEditProductPage(productId: number) {
    this.router.navigate(['/edit-product', productId]);
  }

  filterProductsByManage(manageName: string) {
    const manageId = this.manages.find(manage => manage.name === manageName)?.id;
    if (manageId) {
      this.productService.getProductsByManage(manageId).subscribe((products: Product[]) => {
        this.Products = products;
      });
    } else {
      this.loadProducts();
    }
  }
}
