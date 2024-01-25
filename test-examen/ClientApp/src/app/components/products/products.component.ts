import {Component, OnInit} from '@angular/core';
import {Product} from "../../models/product";
import {ProductService} from "../../services/product.service";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  productList !: Product[];
  productForm: FormGroup;
  constructor(protected productService: ProductService, private formBuilder: FormBuilder) {
    this.productForm = this.formBuilder.group({
      name: '',
      price: '',
      description: '',
    });
  }

  loadProducts() {
    this.productService.getAllProducts().subscribe((products) => {
      this.productList = products;
    })
  }

  addProduct() {
    this.productService.createProduct(this.productForm.value).subscribe((product) => {
      this.loadProducts();
    })
  }

  deleteProduct(id: string) {
    this.productService.deleteProduct(id).subscribe((product) => {
      this.loadProducts();
    })
  }

  ngOnInit() {
    this.loadProducts();
  }
}
