import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";

import { Observable } from "rxjs";

import { Driver } from "./types.services";
const httpOptions = {
  headers: new HttpHeaders({
    "Content-Type": "application/json",
    Authorization: "my-auth-token",
  }),
};

@Injectable()
export class DriverContextService {
  API_URL = "https://localhost:44381/Driver";

  constructor(private http: HttpClient) {}

  getDrivers(): Observable<Driver[]> {
    return this.http.get<Driver[]>(this.API_URL);
  }

  getDriverById(id: string): Observable<Driver[]> {
    id = id.trim();

    const options = id ? { params: new HttpParams().set("id", id) } : {};

    return this.http.get<Driver[]>(this.API_URL, options);
  }

  addHero(driver: Driver): Observable<Driver> {
    return this.http.post<Driver>(this.API_URL, driver, httpOptions);
  }

  deleteHero(id: string): Observable<unknown> {
    const url = `${this.API_URL}/${id}`;
    return this.http.delete(url, httpOptions);
  }

  updateHero(driver: Driver): Observable<Driver> {
    httpOptions.headers = httpOptions.headers.set(
      "Authorization",
      "my-new-auth-token"
    );

    return this.http.put<Driver>(this.API_URL, driver, httpOptions);
  }
}