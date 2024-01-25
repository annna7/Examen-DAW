import {Component, OnInit} from '@angular/core';
import {Order} from "../../models/order";
import {OrderService} from "../../services/order.service";
import {FormBuilder, FormGroup} from "@angular/forms";
import {User} from "../../models/user";
import {Product} from "../../models/product";
import {ProductService} from "../../services/product.service";
import {UserService} from "../../services/user.service";
import {CreateOrderDto} from "../../models/create-order.dto";

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  allOrders: Order[] = [];
  selectedCustomer ?: User;
  allProducts ?: Product[];
  currentProducts ?: Product[];
  allUsers ?: User[];

  constructor(private orderService: OrderService,
              private productService: ProductService,
              private userService: UserService) {}

  loadOrders() {
    this.orderService.getAllOrders().subscribe((orders) => {
      this.allOrders = orders;
    });
  }

  loadProducts() {
    this.productService.getAllProducts().subscribe((products) => {
      this.allProducts = products;
    });
  }

  loadUsers() {
    this.userService.getAllUsers().subscribe((users) => {
      this.allUsers = users;
    });
  }

  addProductToCurrentList(product: Product) {
    if (this.currentProducts === undefined) {
      this.currentProducts = [];
    }
    if (this.currentProducts.includes(product)) {
      return;
    }
    this.currentProducts = [...this.currentProducts, product];
  }

  changeUser(user: any) {
    console.log(user);
    this.selectedCustomer = user;
  }

  createOrder() {
    let order: CreateOrderDto = {
      userId: this.selectedCustomer?.id ?? "",
      productIds: []
    };
    order.productIds = this.currentProducts?.map((product) => product.id) ?? [];
    this.orderService.createOrder(order).subscribe((order) => {
      this.loadOrders();
      this.currentProducts = [];
      this.selectedCustomer = undefined;
    });
  }

  ngOnInit() {
    this.loadUsers();
    this.loadProducts();
    this.loadOrders();
  }
}
