/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { EmployeeDto } from '../../models/employee-dto';

export interface ApiEmployeeGetByIdGet$Json$Params {
  id?: string;
}

export function apiEmployeeGetByIdGet$Json(http: HttpClient, rootUrl: string, params?: ApiEmployeeGetByIdGet$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<EmployeeDto>> {
  const rb = new RequestBuilder(rootUrl, apiEmployeeGetByIdGet$Json.PATH, 'get');
  if (params) {
    rb.query('id', params.id, {});
  }

  return http.request(
    rb.build({ responseType: 'json', accept: 'text/json', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<EmployeeDto>;
    })
  );
}

apiEmployeeGetByIdGet$Json.PATH = '/api/employee/getById';
