import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BridgeModel } from '../BridgeModel';

@Injectable({
  providedIn: 'root',
})
export class BridgeApiService {
  private bridgeurl: string;

  constructor(
    private http: HttpClient,
    @Inject('API_BASE_URL') baseUrl: string
  ) {
    this.bridgeurl = baseUrl + '/apibridge/';
  }

  authenticate(bm: BridgeModel) {
    return this.http.post<any>(this.bridgeurl, bm);
  }

  Post(bm: BridgeModel) {
    return this.http.post<any>(this.bridgeurl, bm);
  }

  History(bm: BridgeModel) {
    return this.http.post<any>(this.bridgeurl, bm);
  }
}
