import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
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

  getDriverById(id: string): Observable<Driver> {
    return this.http.get<Driver>(this.API_URL + `/${id}`);
  }

  addDriver(driver: Driver): Observable<Driver> {
    return this.http.post<Driver>(this.API_URL, driver, httpOptions);
  }

  deleteDriver(id: string): Observable<unknown> {
    const url = `${this.API_URL}/${id}`;
    return this.http.delete(url, httpOptions);
  }

  updateDriver(driver: Driver): Observable<Driver> {
    return this.http.put<Driver>(this.API_URL + `/${driver.id}`, driver);
  }
}
