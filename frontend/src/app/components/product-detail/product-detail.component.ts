import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../models/product.model';
import { Manage } from '../../models/manage.model';
import { ProductService } from '../../services/product.service';
import { ManageService } from '../../services/manage.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-Product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
  standalone: true,
  imports: [  FormsModule, CommonModule ]
})
export class ProductDetailComponent implements OnInit {

Product: Product = {
  title: '', content: '', archived: false, manage: null,  update_time: ''
};

manages: Manage[] = [];
isNewProduct = true;

constructor(
  private ProductService: ProductService,
  private ManageService: ManageService,
  private route: ActivatedRoute,
  private router: Router
) {}

  ngOnInit(): void {
    this.loadManages();
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isNewProduct = false;
      this.loadProduct(parseInt(id, 10));
    }
  }

  loadManages(): void {
    this.ManageService['getManages']().subscribe((manages: Manage[]) => { // Use ['getAllManages'] to access method
      this.manages = manages;
    });
  }

  loadProduct(id: number): void {
    this.ProductService.getProductById(id).subscribe((Product: Product) => { // Ensure to use the correct type for the parameter
      this.Product = Product;
    });
  }


  updateManage(ManageId: number | null): void {
    if (ManageId !== null) {
      if (!this.Product.manage) {
        this.Product.manage = { id: ManageId, name: '' };
      } else {
        this.Product.manage.id = ManageId;
      }
    } else {
      this.Product.manage = null;
    }
  }

  saveProduct(): void {
    if (this.isNewProduct) {
      this.ProductService.createProduct(this.Product).subscribe(() => {
        this.router.navigate(['/products']);
      });
    } else {
      if (this.Product.id != null) { // Check if id is not null or undefined
        this.ProductService.updateProduct(this.Product.id, this.Product).subscribe(() => {
          this.router.navigate(['/products']);
        });
      } else {
        console.error('Product id is null or undefined.'); // Handle the case when id is null or undefined
      }
    }
  }
  
  deleteProduct(): void {
    const id = this.Product.id;
    if (id != null) { // Check if id is not null or undefined
      if (confirm('Are you sure you want to delete this Product?')) {
        this.ProductService.deleteProduct(id).subscribe(() => {
          this.router.navigate(['/products']);
        });
      }
    } else {
      console.error('Product id is null or undefined.'); // Handle the case when id is null or undefined
    }
  }
  cancel() {
    this.router.navigate(['/products']);
    }



}

