import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { UserService } from '../user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-navigationbar',
  templateUrl: './navigationbar.component.html',
  styleUrls: ['./navigationbar.component.css']
})
export class NavigationbarComponent {

  title = 'welcome to Tulia';
  user!: User;
  isadmin: boolean | undefined;

  constructor(
    public userService: UserService
  ) { }


  ngOnInit() {
    //this.userService.getUser()
    this.userService.user.subscribe((x: User) => this.user = x);
  }


  logout() {
    this.userService.logout();
    alert("You have logged out!");
  }

}
