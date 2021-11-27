import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Rules } from './src/models/rules.model';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
  // This rules are only used for test cases
  eventRules: Rules = new Rules('none',11,9,'Individual',5,10,'none');

  // Vars
  eventID: string;
  username: string;
  gameID: string;

  constructor(private http: HttpClient) { }

  /**
   * This method does a POST request to a specifed URL
   * @param val Value to POST
   * @param postURL Location of the request
   * @returns The server response
   */
  Post(val:any,postURL: string){
    return this.http.post<any>(postURL,val,{
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      })
    });
  }

  /**
   * This method does a PUT request to a specifed URL
   * @param val Value to PUT
   * @param updateURL Location of the request
   * @returns The server response
   */
  Put(val:any,updateURL: string){
    return this.http.put<boolean>(updateURL,val);
  }

  /**
   * This method does a GET request to a specified URL
   * @param getURL Location of the request
   * @returns The server response
   */
  Get(getURL: string){
    return this.http.get<any>(getURL);
  }

  /**
   * This method does a DELETE request to a specifed URL
   * @param val Value to DELETE
   * @param updateURL Location of the request
   * @returns The server response
   */
  Delete(val:any,deleteURL: string){
    return this.http.delete(deleteURL,val);
  }
}
