import { LogManager, autoinject } from "aurelia-framework";
import {HttpClient, json} from 'aurelia-fetch-client';
import { IBaseEntity } from "../interfaces/IBaseEntity";
import { AppConfig } from "../app-config";

export var log = LogManager.getLogger('BaseService');

//https://www.typescriptlang.org/docs/handbook/generics.html

export class BaseService<TEntity extends IBaseEntity> {

  private serviceHttpClient: HttpClient;
  private serviceAppConfig: AppConfig;
  private serviceEndPoint: string;

  constructor(
    httpClient: HttpClient,
    appConfig: AppConfig,
    endPoint: string,
  ) {
    log.debug('constructor');
    this.serviceHttpClient = httpClient;
    this.serviceAppConfig = appConfig;
    this.serviceEndPoint = endPoint;
  }



  fetchAll(): Promise<TEntity[]> {
    // TODO: use config
    let url = this.serviceAppConfig.apiUrl + 'v1/' + this.serviceEndPoint;

    return this.serviceHttpClient.fetch(url,
      {
        cache: 'no-store',
        headers: {
          Authorization: 'Bearer ' + this.serviceAppConfig.jwt,
        }
      })
      .then(response => {
        log.debug('resonse', response);
        return response.json();
      })
      .then(jsonData => {
        log.debug('jsonData', jsonData);
        return jsonData;
      }).catch(reason => {
        log.debug('catch reason', reason);
      });
  }

  fetchPast(): Promise<TEntity[]> {
    let url = this.serviceAppConfig.apiUrl + 'v1/' + this.serviceEndPoint + '/past';
    return this.serviceHttpClient.fetch(url,
      {
        cache: 'no-store',
        headers: {
          Authorization: 'Bearer ' + this.serviceAppConfig.jwt,
        }
      })
      .then(response => {
        log.debug('resonse', response);
        return response.json();
      })
      .then(jsonData => {
        log.debug('jsonData', jsonData);
        return jsonData;
      }).catch(reason => {
        log.debug('catch reason', reason);
      });
  }

  fetchBySearch(search: string, topic: number): Promise<TEntity[]> {
    // TODO: use config
    if (search == "") {
      search = "empty_string"
    }
    let url = this.serviceAppConfig.apiUrl + 'v1/' + this.serviceEndPoint + '/' + search + '/' + topic
    console.log(url)
    
    return this.serviceHttpClient.fetch(url,
      {
        cache: 'no-store',
        headers: {
          Authorization: 'Bearer ' + this.serviceAppConfig.jwt,
        }
      })
      .then(response => {
        log.debug('resonse', response);
        return response.json();
      })
      .then(jsonData => {
        log.debug('jsonData', jsonData);
        return jsonData;
      }).catch(reason => {
        log.debug('catch reason', reason);
      });
  }


  // create a new entity
  post(entity: TEntity, file): Promise<Response> {
    let url = this.serviceAppConfig.apiUrl + 'v1/' + this.serviceEndPoint;


    var form = new FormData()
    form.append('image', file)
    this.serviceHttpClient.fetch(url + '/image', {
      method: 'POST',
      //headers: { 'Content-Type': image.type },
      body: form
    })
      .then(response => {
        return response
      })
      .catch(error => {
        console.log("Some Failure...");
        throw error.content;
      })

    return this.serviceHttpClient.post(url, JSON.stringify(entity), {
      cache: 'no-cache',
      
      headers: {
        Authorization: 'Bearer ' + this.serviceAppConfig.jwt,
        Accept: '*/*',
      },
    }).then(
      response => {
        log.debug('response', response);
        return response;
      }
    );

  }

  // get single entity
  fetch(id: number): Promise<TEntity> {
    let url = this.serviceAppConfig.apiUrl + 'v1/' + this.serviceEndPoint + '/' + id;
    
    return this.serviceHttpClient.fetch(url, {
      cache: 'no-store',
      headers: {
        Authorization: 'Bearer ' + this.serviceAppConfig.jwt,
      }
    })
      .then(response => {
        log.debug('resonse', response);
        return response.json();
      })
      .then(jsonData => {
        log.debug('jsonData', jsonData);
        return jsonData;
      }).catch(reason => {
        log.debug('catch reason', reason);
      });
  }


  // update entity
  put(entity: TEntity): Promise<Response> {
    let url = this.serviceAppConfig.apiUrl + 'v1/' + this.serviceEndPoint + '/' + entity.id;

    return this.serviceHttpClient.put(url, JSON.stringify(entity), {
      cache: 'no-store',
      headers: {
        Authorization: 'Bearer ' + this.serviceAppConfig.jwt,
      }
    }).then(
      response => {
        log.debug('response', response);
        return response;
      }
    );

  }

  // delete entity
  delete(id: number): Promise<Response> {
    let url = this.serviceAppConfig.apiUrl + 'v1/' + this.serviceEndPoint + '/' + id;

    return this.serviceHttpClient.delete(url, null, {
      cache: 'no-store',
      headers: {
        Authorization: 'Bearer ' + this.serviceAppConfig.jwt,
      }
    }).then(
      response => {
        log.debug('response', response);
        return response;
      }
    );
  }



}
