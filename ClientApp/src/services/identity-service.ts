import { LogManager, autoinject } from "aurelia-framework";
import { HttpClient } from 'aurelia-fetch-client';
import { IBaseEntity } from "../interfaces/IBaseEntity";
import { AppConfig } from "../app-config";

export var log = LogManager.getLogger('IdentityService');

@autoinject
export class IdentityService {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig,
    private endPoint: string,
  ) {
    log.debug('constructor');
  }

  login(user: string, password: string): Promise<any> {
    let url = this.appConfig.apiUrl + "account/login";
    let loginDTO = {
      email: user,
      password: password
    };

    return this.httpClient.post(url, JSON.stringify(loginDTO), { cache: 'no-store' }).then(
      response => {
        log.debug('response', response);
        return response.json();
      }
    ).catch(
      reason => {
        log.debug('catch reason', reason);
      }
    );

  }

  register(user: string, password: string): Promise<any> {
    let url = this.appConfig.apiUrl + "account/register";
    let registerDTO = {
      email: user,
      password: password
    }

    return this.httpClient.post(url, JSON.stringify(registerDTO), { cache: 'no-store' }).then(
      response => {
        log.debug('response', response);
        return response.json();
      }
    ).catch(
      reason => {
        log.debug('catch reason', reason);
      }
    );

  }


}
