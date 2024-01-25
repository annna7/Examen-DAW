import { Component } from '@angular/core';
import {User} from "../../models/user";
import {UserService} from "../../services/user.service";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {
  userForm: FormGroup;
  userList ?: User[];
  selectedUser: User | undefined;

  constructor(protected userService: UserService, private formBuilder: FormBuilder) {
    this.userForm = this.formBuilder.group({
      name: '',
      email: '',
    });
  }

  onSelect(user: User): void {
    this.selectedUser = user;
  }

  addUser() {
    this.userService.createUser(this.userForm.value).subscribe((user) => {
      this.loadUsers();
    })
  }
  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getAllUsers().subscribe((users) => {
      this.userList = users;
    });
  }

  updateUser(user: User) {
    this.userService.updateUser(user).subscribe((user) => {
      this.loadUsers();
    })
  }

  deleteUser(id: string) {
    this.userService.deleteUser(id).subscribe((user) => {
      this.loadUsers();
    })
  }
}
