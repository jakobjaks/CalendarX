import {PLATFORM, autoinject, LogManager} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import { AppConfig } from "app-config";

export var log = LogManager.getLogger('MainRouter');

@autoinject
export class MainRouter {
  
  public router: Router;

  constructor(private appConfig: AppConfig){
    log.debug('constructor');
  }


  configureRouter(config: RouterConfiguration, router: Router):void {
    log.debug('configureRouter');

    this.router = router;
    config.title = "Contact App - Aurelia";
    config.map(
      [
        {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home'},
        {route: ['Id','singing/singing'], name: 'singing' + 'singing', moduleId: PLATFORM.moduleName('pages/singing/singing'), nav: true, title: 'singing'},


        {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Login'},
        {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Register'},
        {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logout'},

        //{route: '', name: '', moduleId: PLATFORM.moduleName('pages/'), nav: true, title: ''},
        {route: ['AdministrativeUnits','AdministrativeUnits/index'], name: 'AdministrativeUnits' + 'Index', moduleId: PLATFORM.moduleName('pages/administrativeUnits/index'), nav: true, title: 'AdministrativeUnits'},
        {route: 'AdministrativeUnits/create', name: 'AdministrativeUnits' + 'Create', moduleId: PLATFORM.moduleName('pages/administrativeUnits/create'), nav: false, title: 'AdministrativeUnits Create'},
        {route: 'AdministrativeUnits/edit/:id', name: 'AdministrativeUnits' + 'Edit', moduleId: PLATFORM.moduleName('pages/administrativeUnits/edit'), nav: false, title: 'AdministrativeUnits Edit'},
        {route: 'AdministrativeUnits/delete/:id', name: 'AdministrativeUnits' + 'Delete', moduleId: PLATFORM.moduleName('pages/administrativeUnits/delete'), nav: false, title: 'AdministrativeUnits Delete'},
        {route: 'AdministrativeUnits/details/:id', name: 'AdministrativeUnits' + 'Details', moduleId: PLATFORM.moduleName('pages/administrativeUnits/details'), nav: false, title: 'AdministrativeUnits Details'},


        {route: ['AreaOfInterests','AreaOfInterests/index'], name: 'AreaOfInterests' + 'Index', moduleId: PLATFORM.moduleName('pages/areaOfInterests/index'), nav: true, title: 'AreaOfInterests'},
        {route: 'AreaOfInterests/create', name: 'AreaOfInterests' + 'Create', moduleId: PLATFORM.moduleName('pages/areaOfInterests/create'), nav: false, title: 'AreaOfInterests Create'},
        {route: 'AreaOfInterests/edit/:id', name: 'AreaOfInterests' + 'Edit', moduleId: PLATFORM.moduleName('pages/areaOfInterests/edit'), nav: false, title: 'AreaOfInterests Edit'},
        {route: 'AreaOfInterests/delete/:id', name: 'AreaOfInterests' + 'Delete', moduleId: PLATFORM.moduleName('pages/areaOfInterests/delete'), nav: false, title: 'AreaOfInterests Delete'},
        {route: 'AreaOfInterests/details/:id', name: 'AreaOfInterests' + 'Details', moduleId: PLATFORM.moduleName('pages/areaOfInterests/details'), nav: false, title: 'AreaOfInterests Details'},

        {route: ['Events','Events/index', "EventsIndex/:id/:name"], name: 'Events' + 'Index', moduleId: PLATFORM.moduleName('pages/events/index'), nav: false, title: 'Events'},
        {route: 'Events/create', name: 'Events' + 'Create', moduleId: PLATFORM.moduleName('pages/events/create'), nav: false, title: 'Events Create'},
        {route: 'Events/edit/:id', name: 'Events' + 'Edit', moduleId: PLATFORM.moduleName('pages/events/edit'), nav: false, title: 'Events Edit'},
        {route: 'Events/delete/:id', name: 'Events' + 'Delete', moduleId: PLATFORM.moduleName('pages/events/delete'), nav: false, title: 'Events Delete'},
        {route: 'Events/details/:id', name: 'Events' + 'Details', moduleId: PLATFORM.moduleName('pages/events/details'), nav: false, title: 'Events Details'},
        
        {route: ['EventTypes','EventTypes/index'], name: 'EventTypes' + 'Index', moduleId: PLATFORM.moduleName('pages/eventTypes/index'), nav: true, title: 'EventTypes'},
        {route: 'EventTypes/create', name: 'EventTypes' + 'Create', moduleId: PLATFORM.moduleName('pages/eventTypes/create'), nav: false, title: 'EventTypes Create'},
        {route: 'EventTypes/edit/:id', name: 'EventTypes' + 'Edit', moduleId: PLATFORM.moduleName('pages/eventTypes/edit'), nav: false, title: 'EventTypes Edit'},
        {route: 'EventTypes/delete/:id', name: 'EventTypes' + 'Delete', moduleId: PLATFORM.moduleName('pages/eventTypes/delete'), nav: false, title: 'EventTypes Delete'},
        {route: 'EventTypes/details/:id', name: 'EventTypes' + 'Details', moduleId: PLATFORM.moduleName('pages/eventTypes/details'), nav: false, title: 'EventTypes Details'},
        
        {route: ['Locations','Locations/index'], name: 'Locations' + 'Index', moduleId: PLATFORM.moduleName('pages/locations/index'), nav: true, title: 'Locations'},
        {route: 'Locations/create', name: 'Locations' + 'Create', moduleId: PLATFORM.moduleName('pages/locations/create'), nav: false, title: 'Locations Create'},
        {route: 'Locations/edit/:id', name: 'Locations' + 'Edit', moduleId: PLATFORM.moduleName('pages/locations/edit'), nav: false, title: 'Locations Edit'},
        {route: 'Locations/delete/:id', name: 'Locations' + 'Delete', moduleId: PLATFORM.moduleName('pages/locations/delete'), nav: false, title: 'Locations Delete'},
        {route: 'Locations/details/:id', name: 'Locations' + 'Details', moduleId: PLATFORM.moduleName('pages/locations/details'), nav: false, title: 'Locations Details'},

        {route: ['Organizations','Organizations/index'], name: 'Organizations' + 'Index', moduleId: PLATFORM.moduleName('pages/organizations/index'), nav: true, title: 'Organizations'},
        {route: 'Organizations/create', name: 'Organizations' + 'Create', moduleId: PLATFORM.moduleName('pages/organizations/create'), nav: false, title: 'Organizations Create'},
        {route: 'Organizations/edit/:id', name: 'Organizations' + 'Edit', moduleId: PLATFORM.moduleName('pages/organizations/edit'), nav: false, title: 'Organizations Edit'},
        {route: 'Organizations/delete/:id', name: 'Organizations' + 'Delete', moduleId: PLATFORM.moduleName('pages/organizations/delete'), nav: false, title: 'Organizations Delete'},
        {route: 'Organizations/details/:id', name: 'Organizations' + 'Details', moduleId: PLATFORM.moduleName('pages/organizations/details'), nav: false, title: 'Organizations Details'},
        
        {route: ['Performers','Performers/index'], name: 'Performers' + 'Index', moduleId: PLATFORM.moduleName('pages/performers/index'), nav: true, title: 'Performers'},
        {route: 'Performers/create', name: 'Performers' + 'Create', moduleId: PLATFORM.moduleName('pages/performers/create'), nav: false, title: 'Performers Create'},
        {route: 'Performers/edit/:id', name: 'Performers' + 'Edit', moduleId: PLATFORM.moduleName('pages/performers/edit'), nav: false, title: 'Performers Edit'},
        {route: 'Performers/delete/:id', name: 'Performers' + 'Delete', moduleId: PLATFORM.moduleName('pages/performers/delete'), nav: false, title: 'Performers Delete'},
        {route: 'Performers/details/:id', name: 'Performers' + 'Details', moduleId: PLATFORM.moduleName('pages/performers/details'), nav: false, title: 'Performers Details'},
        
        {route: ['TargetAudiences','TargetAudiences/index'], name: 'TargetAudiences' + 'Index', moduleId: PLATFORM.moduleName('pages/targetAudiences/index'), nav: true, title: 'TargetAudiences'},
        {route: 'TargetAudiences/create', name: 'TargetAudiences' + 'Create', moduleId: PLATFORM.moduleName('pages/targetAudiences/create'), nav: false, title: 'TargetAudiences Create'},
        {route: 'TargetAudiences/edit/:id', name: 'TargetAudiences' + 'Edit', moduleId: PLATFORM.moduleName('pages/targetAudiences/edit'), nav: false, title: 'TargetAudiences Edit'},
        {route: 'TargetAudiences/delete/:id', name: 'TargetAudiences' + 'Delete', moduleId: PLATFORM.moduleName('pages/targetAudiences/delete'), nav: false, title: 'TargetAudiences Delete'},
        {route: 'TargetAudiences/details/:id', name: 'TargetAudiences' + 'Details', moduleId: PLATFORM.moduleName('pages/targetAudiences/details'), nav: false, title: 'TargetAudiences Details'},

      ]
    );

  }

}
