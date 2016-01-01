// This file was generated by typhen-api

package submarine

import (
	"app/typhenapi/core"
	submarine "app/typhenapi/type/submarine"
	_submarine_battle "app/typhenapi/web/submarine/battle"
	"bytes"
	"io"
	"io/ioutil"
	"net/http"
)

// WebAPI sends request.
type WebAPI struct {
	baseURI              string
	serializer           typhenapi.Serializer
	Client               *http.Client
	BeforeRequestHandler func(*http.Request)
	Battle               *_submarine_battle.WebAPI
}

// New creates a WebAPI.
func New(baseURI string, serializer typhenapi.Serializer) *WebAPI {
	api := &WebAPI{}
	api.baseURI = baseURI
	api.serializer = serializer
	api.Client = &http.Client{}
	api.Battle = _submarine_battle.New(baseURI, serializer)
	return api
}

// Ping send a ping request.
func (api *WebAPI) Ping(message string) (*submarine.PingObject, error) {
	reqBody := &PingRequestBody{}
	reqBody.Message = message

	reqBodyData, err := reqBody.Bytes(api.serializer)
	if err != nil {
		return nil, err
	}

	req, err := api.createRequest("POST", api.baseURI+"/ping", bytes.NewReader(reqBodyData))
	if err != nil {
		return nil, err
	}

	res, data, err := api.sendRequest(req)
	if err != nil {
		return nil, err
	}
	if res.StatusCode >= 400 {
		return nil, api.tryToDeserializeAPIError(data)
	}

	result := new(submarine.PingObject)
	if err := api.serializer.Deserialize(data, result); err != nil {
		return nil, err
	}
	if err := result.Coerce(); err != nil {
		return nil, err
	}
	return result, nil
}

// SignUp send a signUp request.
func (api *WebAPI) SignUp(name string, password string) (*submarine.SignUpObject, error) {
	reqBody := &SignUpRequestBody{}
	reqBody.Name = name
	reqBody.Password = password

	reqBodyData, err := reqBody.Bytes(api.serializer)
	if err != nil {
		return nil, err
	}

	req, err := api.createRequest("POST", api.baseURI+"/sign_up", bytes.NewReader(reqBodyData))
	if err != nil {
		return nil, err
	}

	res, data, err := api.sendRequest(req)
	if err != nil {
		return nil, err
	}
	if res.StatusCode >= 400 {
		return nil, api.tryToDeserializeAPIError(data)
	}

	result := new(submarine.SignUpObject)
	if err := api.serializer.Deserialize(data, result); err != nil {
		return nil, err
	}
	if err := result.Coerce(); err != nil {
		return nil, err
	}
	return result, nil
}

// Login send a login request.
func (api *WebAPI) Login(name string, password string) (*submarine.LoginObject, error) {
	reqBody := &LoginRequestBody{}
	reqBody.Name = name
	reqBody.Password = password

	reqBodyData, err := reqBody.Bytes(api.serializer)
	if err != nil {
		return nil, err
	}

	req, err := api.createRequest("POST", api.baseURI+"/login", bytes.NewReader(reqBodyData))
	if err != nil {
		return nil, err
	}

	res, data, err := api.sendRequest(req)
	if err != nil {
		return nil, err
	}
	if res.StatusCode >= 400 {
		return nil, api.tryToDeserializeAPIError(data)
	}

	result := new(submarine.LoginObject)
	if err := api.serializer.Deserialize(data, result); err != nil {
		return nil, err
	}
	if err := result.Coerce(); err != nil {
		return nil, err
	}
	return result, nil
}

// FindUser send a findUser request.
func (api *WebAPI) FindUser(name string) (*submarine.FindUserObject, error) {
	reqBody := &FindUserRequestBody{}
	reqBody.Name = name

	reqBodyData, err := reqBody.Bytes(api.serializer)
	if err != nil {
		return nil, err
	}

	req, err := api.createRequest("POST", api.baseURI+"/find_user", bytes.NewReader(reqBodyData))
	if err != nil {
		return nil, err
	}

	res, data, err := api.sendRequest(req)
	if err != nil {
		return nil, err
	}
	if res.StatusCode >= 400 {
		return nil, api.tryToDeserializeAPIError(data)
	}

	result := new(submarine.FindUserObject)
	if err := api.serializer.Deserialize(data, result); err != nil {
		return nil, err
	}
	if err := result.Coerce(); err != nil {
		return nil, err
	}
	return result, nil
}

// CreateRoom send a createRoom request.
func (api *WebAPI) CreateRoom() (*submarine.CreateRoomObject, error) {
	reqBody := &CreateRoomRequestBody{}

	reqBodyData, err := reqBody.Bytes(api.serializer)
	if err != nil {
		return nil, err
	}

	req, err := api.createRequest("POST", api.baseURI+"/create_room", bytes.NewReader(reqBodyData))
	if err != nil {
		return nil, err
	}

	res, data, err := api.sendRequest(req)
	if err != nil {
		return nil, err
	}
	if res.StatusCode >= 400 {
		return nil, api.tryToDeserializeAPIError(data)
	}

	result := new(submarine.CreateRoomObject)
	if err := api.serializer.Deserialize(data, result); err != nil {
		return nil, err
	}
	if err := result.Coerce(); err != nil {
		return nil, err
	}
	return result, nil
}

// GetRooms send a getRooms request.
func (api *WebAPI) GetRooms() (*submarine.GetRoomsObject, error) {
	reqBody := &GetRoomsRequestBody{}

	reqBodyData, err := reqBody.Bytes(api.serializer)
	if err != nil {
		return nil, err
	}

	req, err := api.createRequest("POST", api.baseURI+"/get_rooms", bytes.NewReader(reqBodyData))
	if err != nil {
		return nil, err
	}

	res, data, err := api.sendRequest(req)
	if err != nil {
		return nil, err
	}
	if res.StatusCode >= 400 {
		return nil, api.tryToDeserializeAPIError(data)
	}

	result := new(submarine.GetRoomsObject)
	if err := api.serializer.Deserialize(data, result); err != nil {
		return nil, err
	}
	if err := result.Coerce(); err != nil {
		return nil, err
	}
	return result, nil
}

// JoinIntoRoom send a joinIntoRoom request.
func (api *WebAPI) JoinIntoRoom(roomId int) (*submarine.JoinIntoRoomObject, error) {
	reqBody := &JoinIntoRoomRequestBody{}
	reqBody.RoomId = roomId

	reqBodyData, err := reqBody.Bytes(api.serializer)
	if err != nil {
		return nil, err
	}

	req, err := api.createRequest("POST", api.baseURI+"/join_into_room", bytes.NewReader(reqBodyData))
	if err != nil {
		return nil, err
	}

	res, data, err := api.sendRequest(req)
	if err != nil {
		return nil, err
	}
	if res.StatusCode >= 400 {
		return nil, api.tryToDeserializeAPIError(data)
	}

	result := new(submarine.JoinIntoRoomObject)
	if err := api.serializer.Deserialize(data, result); err != nil {
		return nil, err
	}
	if err := result.Coerce(); err != nil {
		return nil, err
	}
	return result, nil
}

func (api *WebAPI) tryToDeserializeAPIError(data []byte) error {
	apiError := new(submarine.Error)
	if err := api.serializer.Deserialize(data, apiError); err != nil {
		return err
	}

	if err := apiError.Coerce(); err != nil {
		return err
	}

	return apiError
}

func (api *WebAPI) createRequest(method, url string, body io.Reader) (*http.Request, error) {
	req, err := http.NewRequest(method, url, body)
	if err != nil {
		return nil, err
	}

	if api.BeforeRequestHandler != nil {
		api.BeforeRequestHandler(req)
	}

	return req, nil
}

func (api *WebAPI) sendRequest(req *http.Request) (*http.Response, []byte, error) {
	res, err := api.Client.Do(req)
	if err != nil {
		return nil, nil, err
	}
	defer res.Body.Close()

	data, err := ioutil.ReadAll(res.Body)
	if err != nil {
		return nil, nil, err
	}

	return res, data, nil
}
