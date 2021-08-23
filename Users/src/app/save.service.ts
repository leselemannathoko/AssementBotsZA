import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class SaveService {
  //userData: User;

  constructor(private http: HttpClient) {

   
   }
   userData: User = new User();

  registerUser(user: User): Observable<User> {
    return this.http.post<User>(`https://localhost:44301/Person` , user);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`https://localhost:44301/Person`);
  }

  getUsersById(personid: string): Observable<User[]> {
    return this.http.get<User[]>(`https://localhost:44301/Person/` + personid);
  }

   updateUser(person: User): Observable<User> {
     return this.http.put<User>(`https://localhost:44301/Person/${person.id}`, person);
   }

   DeleteUser(id: number): Observable<User> {
    return this.http.delete<User>(`https://localhost:44301/Person/${id}`);
  }
}
