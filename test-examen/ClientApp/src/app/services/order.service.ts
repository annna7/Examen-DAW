import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Order} from "../models/order";
import {CreateOrderDto} from "../models/create-order.dto";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private readonly _http: HttpClient;
  constructor(private http: HttpClient) {
    this._http = http;
  }

  getAllOrders() {
    return this._http.get<Order[]>(`http://localhost:5095/Order/`);
  }

  createOrder(order: CreateOrderDto) {
    return this._http.post<Order>(`http://localhost:5095/Order`, order);
  }
}
