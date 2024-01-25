import {Order} from "./order";

export interface User {
  id: string;
  name: string;
  email: string;
  orders: Order[];
}
