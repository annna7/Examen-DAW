import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Product} from "../models/product";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly _http: HttpClient;
  constructor(private http: HttpClient) {
    this._http = http;
  }

  createProduct(product: Omit<Product, 'id'>) {
    console.log(product);
    return this._http.post<Product>(`${environment.apiUrl}/Product`, product);
  }

  getAllProducts() {
    return this._http.get<Product[]>(`${environment.apiUrl}/Product`);
  }

  deleteProduct(id: string) {
    return this._http.delete<Product>(`${environment.apiUrl}/Product/${id}`);
  }
}
