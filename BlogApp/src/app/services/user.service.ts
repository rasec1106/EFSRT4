import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, catchError } from 'rxjs';
import { User } from '../models/user';
import { ResponseDto } from '../models/response-dto';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  basePath = "https://localhost:7254"
  currentUser: User = {}

  constructor(private httpClient: HttpClient) { }
  getUsers(): Observable<User[]> {
    let url = "/GetUsers"
    return this.httpClient.get<User[]>(this.basePath+url)
  }
  getUserById(id: number): Observable<User> {
    let url = "/GetUserById"    
    const params = new HttpParams().set('id', id)
    return this.httpClient.get<User>(this.basePath+url,{params})
  }
  createUser(user: User): Observable<ResponseDto> {
    let url= "/CreateUser"
    return this.httpClient.post<ResponseDto>(this.basePath+url, user).pipe()
  }
  login(userName: string, password: string){
    let url= "/Login"
    const params = new HttpParams().set('username', userName).set('password', password)
    return this.httpClient.post<ResponseDto>(this.basePath+url, null, {params}).pipe()
  }
  updateUser(user: User): Observable<ResponseDto> {
    let url= "/UpdateUser"
    return this.httpClient.put<ResponseDto>(this.basePath+url, user).pipe()
  }
  deleteUser(userId: number): Observable<ResponseDto> {
    let url= "/DeleteUser"
    const params = new HttpParams().set('id', userId)
    return this.httpClient.delete<ResponseDto>(this.basePath+url, {params}).pipe()
  }
}
