import {Product} from "./product";
import {User} from "./user";

export interface Order {
  id: string;
  userId: string;
  user: User;
  orderDate: Date;
  products: Product[];
}
