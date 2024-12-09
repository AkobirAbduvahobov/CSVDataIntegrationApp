/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { EmployeeDto } from '../../models/employee-dto';

export interface ApiEmployeeGetAllGet$Plain$Params {
  Search?: string;
  SortColumn?: string;
  SortAscending?: boolean;
}

export function apiEmployeeGetAllGet$Plain(http: HttpClient, rootUrl: string, params?: ApiEmployeeGetAllGet$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<EmployeeDto>>> {
  const rb = new RequestBuilder(rootUrl, apiEmployeeGetAllGet$Plain.PATH, 'get');
  if (params) {
    rb.query('Search', params.Search, {});
    rb.query('SortColumn', params.SortColumn, {});
    rb.query('SortAscending', params.SortAscending, {});
  }

  return http.request(
    rb.build({ responseType: 'text', accept: 'text/plain', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<Array<EmployeeDto>>;
    })
  );
}

apiEmployeeGetAllGet$Plain.PATH = '/api/employee/getAll';
