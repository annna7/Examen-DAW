import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "../models/user";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly _http: HttpClient;
  constructor(private http: HttpClient) {
    this._http = http;
  }

  getAllUsers(): Observable<User[]> {
    return this._http.get<User[]>(`${environment.apiUrl}/User`);
  }

  createUser(user: Omit<User, 'id'>): Observable<User> {
    return this._http.post<User>(`${environment.apiUrl}/User`, user);
  }

  updateUser(user: User): Observable<User> {
    return this._http.put<User>(`${environment.apiUrl}/User/${user.id}`, user);
  }

  deleteUser(id: string): Observable<User> {
    return this._http.delete<User>(`${environment.apiUrl}/User/${id}`);
  }
}
