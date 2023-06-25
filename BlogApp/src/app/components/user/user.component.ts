import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  users: User[] = []
  changePassword: boolean = false
  loginEventSubscription: Subscription = new Subscription()

  constructor(private userService: UserService, private router: Router){
    this.userService.getUsers().subscribe(res=>{
      this.users = res
    })
  }
}
