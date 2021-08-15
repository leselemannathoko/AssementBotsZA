import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class SaveService {
  constructor(private http: HttpClient) { }


  registerUser(user: User): Observable<User> {
    return this.http.post<User>(`https://localhost:44301/Person` , user);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`https://localhost:44301/Person`);
  }

   updateUser(person: User) {
     return this.http.put(`https://localhost:44301/Person/${person._id}`, person);
   }
}
