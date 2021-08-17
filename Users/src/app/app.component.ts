import { Component, OnInit } from '@angular/core';
import { SaveService } from './save.service';
import { User } from './models/user';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Users';
  users: User[];
  selecteduser: User;
  userData: User;

  constructor( private saveService: SaveService) {
    //Data: User = new User();

  }

  ngOnInit() {
   this.loadUsers();
  }


  
postUsers() {
    this.saveService.registerUser(this.userData).subscribe((user: User) => {
      this.loadUsers();
    });
  }

updateUsers() {
  console.log(this.userData);
   this.saveService.updateUser(this.userData).subscribe(() => {
     this.loadUsers();
   });
}

populateForm(SelectedPerson : User)
 {
   this.userData = Object.assign({}, SelectedPerson)
 }

loadUsers() {
    this.saveService.getUsers().subscribe((users: User[]) => {
      this.users = users;
    }, error => {
      console.error();
    });
  }

deleteUser(personid: string)
{
  this.saveService.DeleteUser(personid).subscribe(() => {

});

}  


}

