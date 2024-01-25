import {Component, OnInit} from '@angular/core';
import {UserService} from "../../services/user.service";
import {User} from "../../models/user";
import {FormBuilder, FormGroup, FormsModule} from "@angular/forms";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  homeForm: FormGroup;
  userList !: User[];
  constructor(protected userService: UserService, private formBuilder: FormBuilder) {
    this.homeForm = this.formBuilder.group({
      name: '',
      email: '',
    });
  }

  addUser() {
    this.userService.createUser(this.homeForm.value).subscribe((user) => {
      this.loadUsers();
    })
  }
  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getAllUsers().subscribe((users) => {
      this.userList = users;
    })
  }
}
