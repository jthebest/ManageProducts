import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ManageService } from '../../services/manage.service';
import { Product } from '../../models/product.model';
import { Manage } from '../../models/manage.model';
import { ProductService } from '../../services/product.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule]
})
export class FilterComponent implements OnInit {
  manages: Manage[] = [];
  selectedManage: Manage | null = null;
  filteredProducts: Product[] = []; // Array to hold filtered Products

  @Output() filterChanged = new EventEmitter<Product[]>(); // Emit filtered Products array

  constructor(private ManageService: ManageService, private ProductService: ProductService) { }

  ngOnInit(): void {
    this.getManages();
    this.getAllProducts();

  }

  getManages(): void {
    this.ManageService.getManages()
      .subscribe(manages => this.manages = manages);
  }

  getAllProducts(): void {
    this.ProductService.getProducts()
      .subscribe(Products => {
        this.filteredProducts = Products;
        this.filterChanged.emit(this.filteredProducts);
      });
  }

  filterProductsByManage(): void {
    // Check if selectedManage is not null before accessing its id property
    const ManageId = this.selectedManage?.id;

    if (ManageId) {
      this.ProductService.getProductsByManage(ManageId)
        .subscribe(filteredProducts => {
          this.filteredProducts = filteredProducts;
          this.filterChanged.emit(this.filteredProducts); // Emit filtered Products array
        });
    } else {
      this.getAllProducts(); // If selectedManage is null, show all Products
    }
  }
}
